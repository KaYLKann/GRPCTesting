using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcService
{
    partial class ExponentiationRequest {
        public ExponentiationRequest(Types.Op operation, int value) {
            Operation = operation;
            Value     = value;
        }
    }
}
