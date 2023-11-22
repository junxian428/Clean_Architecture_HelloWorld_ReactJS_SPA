using AutoMapper;
using NUnit.Framework;
using Project3.Application.Common.Interfaces;
using Project3.Application.Common.Models;
using Project3.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Project3.Application.TodoLists.Queries.GetTodos;
using Project3.Domain.Entities;
using System.Reflection;
using System.Runtime.Serialization;

namespace Project3.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(TodoList), typeof(TodoListDto))]
        [TestCase(typeof(TodoItem), typeof(TodoItemDto))]
        [TestCase(typeof(TodoList), typeof(LookupDto))]
        [TestCase(typeof(TodoItem), typeof(LookupDto))]
        [TestCase(typeof(TodoItem), typeof(TodoItemBriefDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            // TODO: Figure out an alternative approach to the now obsolete `FormatterServices.GetUninitializedObject` method.
#pragma warning disable SYSLIB0050 // Type or member is obsolete
            return FormatterServices.GetUninitializedObject(type);
#pragma warning restore SYSLIB0050 // Type or member is obsolete
        }
    }
}