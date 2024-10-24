using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights {

    public class Indexer { // класс для работы с подмассивом исходного массива
        private readonly double[] array; // исходный массив
        private readonly int start; // начало подмассива
        private readonly int length; // длина подмассива

        public Indexer(double[] sourceArray, int start, int length) { // конструктор класса 
            if (start < 0 || start > sourceArray.Length || length < 0 || start + length > sourceArray.Length) { // выходит за пределы массива?
                throw new ArgumentException();
            }
            this.array = sourceArray; // задает исходный массив
            this.start = start; // начало подмассива
            this.length = length; // его длину
        }

        public double this[int index] {  // индексатор класса
            get { // возвращает элемент подмассива по индексу
                if (index < 0 || index >= length) { // индекс отрицательный или больше, чем длина подмассива
                    throw new IndexOutOfRangeException();
                }
                return array[start + index]; // возвращаем элемент исходного массива
            }
            set { // устанавливает элемент подмассива по индексу
                if (index < 0 || index >= length) { // индекс отрицательный или больше, чем длина подмассива
                    throw new IndexOutOfRangeException();
                }
                array[start + index] = value; // устанавливаем новое значение элемента исходного массива
            }
        }

        public int Length { // свойство класса
            get { return length; } // возвращает длину подмассива
        }

        public double[] ToArray() { // метод класса
            double[] result = new double[length]; // создаем новый массив указанной длины.
            // копируем элементы исходного массива, начиная с индекса start, в новый массив.
            Array.Copy(array, start, result, 0, length);  // создаём копию подмассива в виде нового массива
            return result; // возвращаем новый массив.
        }

        public static implicit operator double[](Indexer indexer) { // оператор неявного приведения типов
            return indexer.ToArray(); // получать подмассив в виде нового массива
        }
    }
}
