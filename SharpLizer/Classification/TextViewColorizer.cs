
﻿using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Media;


namespace SharpLizer.Classification
{
    internal class TextViewColorizer
    {
        // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.
#pragma warning disable 649

        [Import]
        private IClassificationFormatMapService _classificationFormatMapService;

        [Import]
        private IClassificationTypeRegistryService _registryService;

        [Import]
        private IStandardClassificationService _standarClassificationService;


#pragma warning restore 649

        private readonly ITextView _textView;
        private IClassificationFormatMap _classificationFormatMap;
        private IEnumerable<IClassificationType> _sharpLizerTypes;

        internal TextViewColorizer(ITextView textView)
        {
            _textView = textView;
            SatisfyImports();
        }

        void EnsureReferences()
        {
            if (_classificationFormatMapService == null || _registryService == null) SatisfyImports();
            if (_classificationFormatMap == null) _classificationFormatMap = _classificationFormatMapService.GetClassificationFormatMap(_textView);
            if (_sharpLizerTypes == null) _sharpLizerTypes = _classificationFormatMap.CurrentPriorityOrder.Where(x => x?.Classification.Contains("SharpLizer") == true).ToList();
        }

        internal void UpdateColors(IEnumerable<CategoryItemDecorationSettings> changedItems)
        {
            try
            {
                EnsureReferences();

                if (_classificationFormatMap.IsInBatchUpdate) return;
                _classificationFormatMap.BeginBatchUpdate();

                foreach (CategoryItemDecorationSettings changedItem in changedItems)
                {
                    UpdateItemDecorationSettings(changedItem);
                }
            }
            catch (Exception)
            {
                //TO-DO: Log exception
            }
            finally
            {
                _classificationFormatMap.EndBatchUpdate();
            }
        }
      
        void UpdateItemDecorationSettings(CategoryItemDecorationSettings changedItem, bool setDefaultTextProperties = false)
        {
            string classificationKey = changedItem.DisplayName.Replace(" ", "");
            IClassificationType classificationType = _sharpLizerTypes.FirstOrDefault(x => x.Classification.Contains(classificationKey));
            if (classificationType == null) return;

            if (setDefaultTextProperties || (changedItem.ForegroundColor == default(Color) && changedItem.BackgroundColor == default(Color)))
            {
                var defaultProperties = GetDefaultClassificationTextProperties(classificationKey);
                _classificationFormatMap.SetExplicitTextProperties(classificationType, defaultProperties);
            }
            else
            {
                TextFormattingRunProperties textProperties = CreateTextProperties(changedItem);
                _classificationFormatMap.SetExplicitTextProperties(classificationType, textProperties);
            }
        }
        internal void RestoreAllColorsToDefaults()
        {
            foreach (var classificationType in _sharpLizerTypes)
            {
                _classificationFormatMap.SetExplicitTextProperties(classificationType, _classificationFormatMap.DefaultTextProperties);
            }
        }

        internal void ChangeColorToDefaults(CategoryItemDecorationSettings item)
        {
            UpdateItemDecorationSettings(item, true);
        }

        private void SatisfyImports()
        {
            if (Common.Instances.ServiceProvider != null)
            {
                Common.Instances.ServiceProvider.SatisfyImportsOnce(this);
            }
        }

        private TextFormattingRunProperties CreateTextProperties(CategoryItemDecorationSettings colorSetting)
        {
            TextFormattingRunProperties textFormatting = TextFormattingRunProperties.CreateTextFormattingRunProperties();
            textFormatting = textFormatting.SetBackground(colorSetting.BackgroundColor);
            textFormatting = textFormatting.SetForeground(colorSetting.ForegroundColor);
            textFormatting = textFormatting.SetBold(colorSetting.IsBold);
            textFormatting = textFormatting.SetItalic(colorSetting.IsItalic);

            if (colorSetting.HasStrikethrough || colorSetting.IsUnderlined)
            {
                TextDecorationCollection decorationsCollection = new TextDecorationCollection();
                TextDecorationCollection decorations = textFormatting.TextDecorations.Clone();

                if (colorSetting.IsUnderlined) decorations.Add(TextDecorations.Underline);
                if (colorSetting.HasStrikethrough) decorations.Add(TextDecorations.Strikethrough);

                decorationsCollection.Add(decorations);
               textFormatting = textFormatting.SetTextDecorations(decorationsCollection);
            }

            return textFormatting;
        }
      
        private TextFormattingRunProperties GetDefaultClassificationTextProperties(string classificationName)
        {
            IClassificationType classificationType;
            var textProperties = TextFormattingRunProperties.CreateTextFormattingRunProperties();
            if (classificationName.Contains("Keyword"))
            {
                classificationType = _standarClassificationService.Keyword;
                textProperties = _classificationFormatMap.GetTextProperties(classificationType);
            }

            if (classificationName.Contains("Identifier"))
            {
                var identifierName = classificationName.Replace("Identifier","");
                textProperties = GetDefaultIdentifierTextProperties(identifierName);
            }

            if(classificationName.Contains("Field") || classificationName.Contains("Property") || classificationName.Contains("Variable"))
            {
                classificationType = _standarClassificationService.SymbolReference;
                textProperties = _classificationFormatMap.GetTextProperties(classificationType);
            }
            return textProperties;
        }

        
        TextFormattingRunProperties GetDefaultIdentifierTextProperties(string identifier)
        {
            IClassificationType classification;
            switch (identifier)
            {
                case "Class":
                case "Struct":
                case "Delegate":
                  classification =  _classificationFormatMap.CurrentPriorityOrder.FirstOrDefault(classificationType => classificationType?.Classification == "class name");
                    break;

                case "Interface":
                case "Enum":
                    classification = _classificationFormatMap.CurrentPriorityOrder.FirstOrDefault(classificationType => classificationType?.Classification == "enum name");
                    break;
                default:
                    classification = _standarClassificationService.Identifier;
                    break;
            }

            if (classification == null) return null;
            return _classificationFormatMap.GetTextProperties(classification);
        }
    }
}