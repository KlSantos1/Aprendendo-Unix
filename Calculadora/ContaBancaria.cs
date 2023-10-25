using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class ContaBancaria
    {

        private String titular;
        private Double saldo;
        private int qntdSaques;
        private int qntdDepositos;
        private int qntdTransferencias;

        public String getTitular()
        {
            return titular;
        }

        public Double getSaldo()
        {
            return saldo;
        }

        public int getQntdSaques()
        {
            return qntdSaques;
        }

        public int getQntdDepositos()
        {
            return qntdDepositos;
        }

        public int getQntdTransferencias()
        {
            return qntdTransferencias;
        }

        public ContaBancaria(string titular, double saldo)
        {
            this.titular = titular;
            this.saldo = saldo;
            this.qntdSaques = 0;
            this.qntdDepositos = 1;
        }

        public void depositar(Double valor) 
        {

            if (valor > 0)
            {
                saldo += valor;
                qntdDepositos++;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor));
            }

        }

        public void sacar(Double valor)
        {

            if (valor<=saldo&&valor>0)
            {
                saldo -= valor;
                qntdSaques++;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor));
            }

        }

        public void transferir(ContaBancaria contaBancaria, Double valor)
        {
            if (contaBancaria == null)
            {
                throw new ArgumentNullException(nameof(contaBancaria));
            }

            if (valor <= 0 || valor > saldo)
            {
                throw new ArgumentOutOfRangeException(nameof(valor));
            }

            contaBancaria.depositar(valor);
            this.saldo -= valor;
            qntdTransferencias++;
        }

    }

}
