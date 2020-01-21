using System;

namespace Calculator {
    public interface IExponentiationOperation<T> where T : struct {
        T Calculate(T value, T power);
    }
}