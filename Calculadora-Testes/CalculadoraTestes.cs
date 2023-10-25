using System;
using Xunit;
using Projeto;

namespace Calculadora_Testes
{
    public class CalculadoraTests
    {
        [Fact(DisplayName = "Teste de Soma")]
        [Trait("Category","Operadores")]
        public void TestSomar()
        {
            // Arrange
            int num1 = 5;
            int num2 = 3;

            // Act
            int resultado = Calculadora.Somar(num1, num2);

            // Assert
            Assert.Equal(8, resultado);
        }

        [Fact(DisplayName = "Teste de Subtração")]
        [Trait("Category", "Operadores")]
        public void TestSubtrair()
        {
            // Arrange
            int num1 = 10;
            int num2 = 4;

            // Act
            int resultado = Calculadora.Subtrair(num1, num2);

            // Assert
            Assert.Equal(6, resultado);
        }

        [Fact(DisplayName = "Teste de Multiplicação")]
        [Trait("Category", "Operadores")]
        public void TestMultiplicar()
        {
            // Arrange
            int num1 = 6;
            int num2 = 7;

            // Act
            int resultado = Calculadora.Multiplicar(num1, num2);

            // Assert
            Assert.Equal(42, resultado);
        }

        [Fact(DisplayName = "Teste de Divisão")]
        [Trait("Category", "Operadores")]
        public void TestDividir()
        {
            // Arrange
            int num1 = 20;
            int num2 = 4;

            // Act
            int resultado = Calculadora.Dividir(num1, num2);

            // Assert
            Assert.Equal(5, resultado);
        }
    }

}