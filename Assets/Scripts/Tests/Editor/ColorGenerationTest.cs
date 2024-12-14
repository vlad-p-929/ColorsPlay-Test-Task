using System.Collections.Generic;
using ColorsPlay.Core;
using NUnit.Framework;
using UnityEngine;

public class ColorGenerationTest
{
    private GameModel model;

    [SetUp]
    public void Initialize()
    {
        model = new GameModel(colorsCount: 3);
    }
    
    [Test]
    public void ColorsAreUniqueInMultipleIterations()
    {
        const int iterations = 100;

        for (int i = 0; i < iterations; i++)
        {
            model.GenerateColors();
            
            List<Color> generatedColors = model.CurrentColors;

            for (int j = 0; j < generatedColors.Count; j++)
            {
                for (int k = j + 1; k < generatedColors.Count; k++)
                {
                    Assert.AreNotEqual(generatedColors[j], generatedColors[k],
                        $"Duplicate colors found in iteration {i}: Color1 {generatedColors[j]}, Color2 {generatedColors[k]}");
                }
            }
        }
    }

    [Test]
    public void TargetColorPresentInTheGeneratedCollection()
    {
        model.GenerateColors();

        bool isContains = model.CurrentColors.Contains(model.TargetColor);

        Assert.IsTrue(isContains,
            $"Target Color {model.TargetColor} doesn't present in generated collection.\n " +
            $"Col1: {model.CurrentColors[0]} Col2: {model.CurrentColors[1]} Col3: {model.CurrentColors[2]}");
    }
}
