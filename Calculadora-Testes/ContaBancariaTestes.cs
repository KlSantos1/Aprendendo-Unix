using System;
using Xunit;
using Projeto;

namespace ContaBancaria_Testes
{
    public class ContaBancariaTestes
    {
 
        // Definindo que vai ser um teste de um fato e nome do teste
        [Fact(DisplayName = "Teste de Depósito Único")]
        public void depositar_fundos_atualiza_saldo()
        {
            //Arrange
            var conta = new ContaBancaria("Kauã", 1000.0);

            //Act
            conta.depositar(1000);

            //Assert
            Assert.Equal(2000, conta.getSaldo());

        }

        // Definindo a fonte de dados para o teste de teoria
        public static IEnumerable<object[]> DadosDeposito =>
        new List<object[]>
        {
        new object[] { 1000.0, 2000.0, "Depósito de 1000.0 deve resultar em saldo de 2000.0" },
        new object[] { 1.0, 1001.0, "Depósito de 1.0 deve resultar em saldo de 1001.0" },
        new object[] { 500.0, 1500.0, "Depósito de 500.0 deve resultar em saldo de 1500.0" },
        new object[] { 4000.0, 5000.0, "Depósito de 4000.0 deve resultar em saldo de 5000.0" }
        };

        [Theory]
        [MemberData(nameof(DadosDeposito))]
        public void depositar_fundos_atualiza_saldo_theory(Double valor, Double esperado, string displayName)
        {
            // Arrange
            var conta = new ContaBancaria("Kauã", 1000.0);

            // Act
            conta.depositar(valor);

            // Assert
            Assert.Equal(esperado, conta.getSaldo());
        }

        public static IEnumerable<object[]> DadosDepositoErro =>
        new List<object[]>
        {
        new object[] { 0.0, "Depósito de 0.0 deve resultar em erro" },
        new object[] { -999.0, "Depósito de -999.0 deve resultar em erro" },
        };

        [Theory]
        [MemberData(nameof(DadosDepositoErro))]
        public void depositar_fundos_negativos_e_zero_da_erro_theory(Double valor, string displayName)
        {
            // Arrange
            var conta = new ContaBancaria("Kauã", 1000.0);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => conta.depositar(valor));
        }

        public static IEnumerable<object[]> DadosSaque =>
       new List<object[]>
       {
        new object[] { 1000.0, 0.0, "Saque de 1000.0 deve resultar em saldo de 0.0" },
        new object[] { 500.0, 500.0, "Saque de 500.0 deve resultar em saldo de 500.0" }
       };

        [Theory]
        [MemberData(nameof(DadosSaque))]
        public void sacar_fundos_atualiza_saldo_theory(Double valor, Double esperado, string displayName)
        {
            // Arrange
            var conta = new ContaBancaria("Kauã", 1000.0);

            // Act
            conta.sacar(valor);

            // Assert
            Assert.Equal(esperado, conta.getSaldo());
        }

        public static IEnumerable<object[]> DadosSaqueErro =>
      new List<object[]>
      {
        new object[] { 0.0, "Saque de 0.0 deve resultar em erro" },
        new object[] { -999.0, "Saque de -999.0 deve resultar em erro" },
      };

        [Theory]
        [MemberData(nameof(DadosSaqueErro))]
        public void sacar_fundos_negativos_e_zero_da_erro_theory(Double valor, string displayName)
        {
            // Arrange
            var conta = new ContaBancaria("Kauã", 1000.0);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => conta.sacar(valor));
        }

        public static IEnumerable<object[]> Dadostransferencia =>
      new List<object[]>
      {
        new object[] { 1000.0, "Transferência de 1000.00 deve resultar em um saldo de 0.0 para contaRemetente e 3000.0 para contaDestinataria" },
        new object[] { 500.0, "Transferência de 500.00 deve resultar em um saldo de 500.0 para contaRemetente e 2500.0 para contaDestinataria" },
      };

        [Theory]
        [MemberData(nameof (Dadostransferencia))]
        public void transferir_fundos_atualiza_saldo_contas(Double valor, string displayName)
        {

            // Arrange
            var contaRemetente = new ContaBancaria("Kauã", 1000.0);
            var contaDestinataria = new ContaBancaria("Cleiton", 2000.0);
            var esperadoRemetente = contaRemetente.getSaldo() - valor;
            var esperadoDestinataria = contaDestinataria.getSaldo() + valor;

            // Act
            contaRemetente.transferir(contaDestinataria, valor);

            // Assert
            Assert.Equal(esperadoRemetente, contaRemetente.getSaldo());
            Assert.Equal(esperadoDestinataria, contaDestinataria.getSaldo());

        }

        public static IEnumerable<object[]> DadosTransferenciaErro =>
    new List<object[]>
    {
        new object[] { 0.0, "Transferência de 0.0 deve resultar em erro" },
        new object[] { -500.0, "Transferência de -500.0 deve resultar em erro" },
    };

        [Theory]
        [MemberData(nameof(DadosTransferenciaErro))]
        public void transferir_fundos_negativos_e_zero_da_erro(Double valor, string displayName)
        {
            // Arrange
            var contaRemetente = new ContaBancaria("Kauã", 1000.0);
            var contaDestinataria = new ContaBancaria("Cleiton", 2000.0);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => contaRemetente.transferir(contaDestinataria, valor));
        }

        public static IEnumerable<object[]> DadosTransferenciaContaNula =>
    new List<object[]>
    {
        new object[] { 1000.0, null, "Conta remetente nula deve resultar em erro" },
    };

        [Theory]
        [MemberData(nameof(DadosTransferenciaContaNula))]
        public void transferir_fundos_erro_conta(Double valor, ContaBancaria contaDestinataria, string displayName)
        {
            // Arrange
            var contaRemetente = new ContaBancaria("Kauã", 1000.0);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => contaRemetente.transferir(contaDestinataria, valor));
        }

    }
}
