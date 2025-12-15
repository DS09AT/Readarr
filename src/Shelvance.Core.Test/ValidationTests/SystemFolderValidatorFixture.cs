using System;
using System.IO;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Core.Books;
using Shelvance.Core.Test.Framework;
using Shelvance.Core.Validation.Paths;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.ValidationTests
{
    public class SystemFolderValidatorFixture : CoreTest<SystemFolderValidator>
    {
        private TestValidator<Author> _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new TestValidator<Author>
                            {
                                v => v.RuleFor(s => s.Path).SetValidator(Subject)
                            };
        }

        [Test]
        public void should_not_be_valid_if_set_to_windows_folder()
        {
            WindowsOnly();

            var author = Builder<Author>.CreateNew()
                                        .With(s => s.Path = Environment.GetFolderPath(Environment.SpecialFolder.Windows))
                                        .Build();

            _validator.Validate(author).IsValid.Should().BeFalse();
        }

        [Test]
        public void should_not_be_valid_if_child_of_windows_folder()
        {
            WindowsOnly();

            var author = Builder<Author>.CreateNew()
                                        .With(s => s.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Test"))
                                        .Build();

            _validator.Validate(author).IsValid.Should().BeFalse();
        }

        [Test]
        public void should_not_be_valid_if_set_to_bin_folder()
        {
            PosixOnly();

            var bin = OsInfo.IsOsx ? "/System" : "/bin";
            var author = Builder<Author>.CreateNew()
                                        .With(s => s.Path = bin)
                                        .Build();

            _validator.Validate(author).IsValid.Should().BeFalse();
        }

        [Test]
        public void should_not_be_valid_if_child_of_bin_folder()
        {
            PosixOnly();

            var bin = OsInfo.IsOsx ? "/System" : "/bin";
            var author = Builder<Author>.CreateNew()
                .With(s => s.Path = Path.Combine(bin, "test"))
                .Build();

            _validator.Validate(author).IsValid.Should().BeFalse();
        }
    }
}
