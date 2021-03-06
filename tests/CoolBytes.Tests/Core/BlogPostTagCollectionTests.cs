﻿using System.Linq;
using CoolBytes.Core.Collections;
using CoolBytes.Core.Domain;
using Xunit;

namespace CoolBytes.Tests.Core
{
    public class BlogPostTagCollectionTests
    {
        private readonly BlogPostTagCollection _collection;

        public BlogPostTagCollectionTests()
        {
            _collection = new BlogPostTagCollection();
        }

        [Fact]
        public void ShouldContainOneItem()
        {
            var item = new BlogPostTag("Test");

            _collection.Add(item);

            Assert.Equal(1, _collection.Count);
        }

        [Fact]
        public void ShouldNotInsertDuplicateItem()
        {
            var item = new BlogPostTag("TEST");
            var itemDuplicate = new BlogPostTag("test");

            _collection.Add(item);
            _collection.Add(itemDuplicate);

            Assert.Equal(1, _collection.Count);
        }

        [Fact]
        public void ShouldUpdateCorrectly()
        {
            _collection.Add(new BlogPostTag("Test1"));
            _collection.Add(new BlogPostTag("Test2"));
            var newItem = new[] { new BlogPostTag("Test1") };

            _collection.Update(newItem);

            Assert.Equal(1, _collection.Count);
            Assert.Equal("Test1", _collection.First().Name);
        }

        [Fact]
        public void ShouldPreserveIdsCorrectly()
        {
            var currentItem = new BlogPostTag("Test");
            SetId(currentItem, 1);
            _collection.Add(currentItem);

            var newItem = new[] { new BlogPostTag("Test") };
            SetId(newItem.First(), 2);

            _collection.Update(newItem);

            Assert.Equal(1, _collection.First().Id);
        }

        private static void SetId(BlogPostTag item, int id) =>
            item.GetType().GetProperty("Id").SetValue(item, id);
    }
}
