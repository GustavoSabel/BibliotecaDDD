using Biblioteca.Domain.LivroContext.ValueObjects;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace Biblioteca.Tests.LivroContexto
{
    public class TituloTest
    {
        [Xunit.Theory]
        [Xunit.InlineData("Titulo", "SubTitulo")]
        [Xunit.InlineData("Titulo", null)]
        [Xunit.InlineData("Titulo dasdasasasdasd asd as dasd asd asd as as", "dasdsad as dasd as askd jas asahshdgasjhdasdgash dgasj")]
        public void Criar(string principal, string subTitulo)
        {
            var t = new Titulo(principal, subTitulo);
            t.Principal.Should().Be(principal);
            t.SubTitulo.Should().Be(subTitulo);
        }

        [Xunit.Theory]
        [Xunit.InlineData("Titulo", "SubTitulo")]
        [Xunit.InlineData("Titulo", null)]
        [Xunit.InlineData("Titulo dasdasasasdasd asd as dasd asd asd as as", "dasdsad as dasd as askd jas asahshdgasjhdasdgash dgasj")]
        public void Comparar(string principal, string subTitulo)
        {
            var t1 = new Titulo(principal, subTitulo);
            var t2 = new Titulo(principal, subTitulo);
            var t3 = new Titulo("A", "A");
            var t4 = new Titulo("A", null);

            (t1 == t2).Should().BeTrue();
            (t1 == t2).Should().BeTrue();
            (t1 == t3).Should().BeFalse();
            (t1 == t4).Should().BeFalse();
        }

        [Xunit.Theory]
        [Xunit.InlineData("Titulo", "SubTitulo", "Titulo: SubTitulo")]
        [Xunit.InlineData("Titulo", null, "Titulo")]
        public void TestToString(string principal, string subTitulo, string resultado)
        {
            new Titulo(principal, subTitulo).ToString().Should().Be(resultado);
        }
    }
}
