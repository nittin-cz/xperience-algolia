﻿using Kentico.Xperience.AlgoliaSearch.Helpers;

using NUnit.Framework;

using System;

using static Kentico.Xperience.AlgoliaSearch.Test.TestSearchModels;

namespace Kentico.Xperience.AlgoliaSearch.Test
{
    [TestFixture]
    internal class AttributeTests : AlgoliaTest
    {
        [Test]
        [TestCase(Model1.IndexName, ExpectedResult = new string[] { "Prop1", "searchable(ClassName)" })]
        [TestCase(Model2.IndexName, ExpectedResult = new string[] { "filterOnly(Prop1)", "searchable(Prop2)", "searchable(ClassName)" })]
        [TestCase(Model4.IndexName, ExpectedResult = new string[] { "searchable(ClassName)" })]
        public string[] FacetableAttributesConvertedToAlgoliaFormat(string indexName)
        {
            return AlgoliaSearchHelper.GetIndexSettings(indexName).AttributesForFaceting.ToArray();
        }


        [Test]
        public void MultipleFacetableOptionsThrows()
        {
            Assert.Throws<InvalidOperationException>(() => AlgoliaSearchHelper.GetIndexSettings(Model6.IndexName));
        }


        [Test]
        [TestCase(Model1.IndexName, ExpectedResult = new string[] { "Prop1", "ObjectID", "ClassName", "Url" })]
        [TestCase(Model2.IndexName, ExpectedResult = new string[] { "ObjectID", "ClassName", "Url" })]
        [TestCase(Model5.IndexName, ExpectedResult = new string[] { "Prop1", "Prop2", "ObjectID", "ClassName", "Url" })]
        public string[] RetrievableAttributesConvertedToAlgoliaFormat(string indexName)
        {
            return AlgoliaSearchHelper.GetIndexSettings(indexName).AttributesToRetrieve.ToArray();
        }


        [Test]
        [TestCase(Model1.IndexName, ExpectedResult = new string[] { "Prop1", "DocumentPublishFrom", "DocumentPublishTo" })]
        [TestCase(Model2.IndexName, ExpectedResult = new string[] { "Prop1", "Prop2", "DocumentPublishFrom", "DocumentPublishTo" })]
        [TestCase(Model3.IndexName, ExpectedResult = new string[] { "Prop2,Prop3", "Prop1", "DocumentPublishFrom", "DocumentPublishTo" })]
        [TestCase(Model4.IndexName, ExpectedResult = new string[] { "DocumentPublishFrom", "DocumentPublishTo" })]
        [TestCase(Model5.IndexName, ExpectedResult = new string[] { "Prop1,Prop2", "Prop3", "unordered(Prop4)", "Prop5", "unordered(Prop6)", "DocumentPublishFrom", "DocumentPublishTo" })]
        public string[] SearchableAttributesConvertedToAlgoliaFormat(string indexName)
        {
            return AlgoliaSearchHelper.GetIndexSettings(indexName).SearchableAttributes.ToArray();
        }
    }
}