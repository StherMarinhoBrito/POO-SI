﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods_2024_2.src {
    public class Ordenador<T>{

        private T[] _dados;
        private Comparer<T> _meuComparador;

        public Ordenador(T[] dados) {
            _dados = dados;
            _meuComparador = Comparer<T>.Default;
        }

        public Ordenador(T[] dados, Comparer<T> comparador) {
            _dados = dados;
            _meuComparador = comparador;
        }

        public T[] ordenar() {
            _dados = QuickSort(_dados, 0, _dados.Length-1);
            return _dados;
        }

        private T[] QuickSort(T[] dados, int inicio, int fim) {
            if(fim > inicio) { 
                int particao = Particao(dados, inicio, fim);
                dados = QuickSort(dados, inicio, particao-1);
                dados = QuickSort(dados, particao+1, fim);
            }
            return dados;
        }

        private int Particao(T[] dados, int inicio, int fim) {
            T pivot = dados[fim];
            
            int particao = inicio - 1;

            for (int i = inicio; i < fim; i++)
            {
                if (_meuComparador.Compare(dados[i], pivot) < 0) {
                    particao++;
                    T temporario = dados[i];
                    dados[i] = dados[particao];
                    dados[particao] = temporario;
                }
            }
            particao++;
            T tempPivot = dados[fim];
            dados[fim] = dados[particao];
            dados[particao] = tempPivot;
            return particao;
        }
    }
}
