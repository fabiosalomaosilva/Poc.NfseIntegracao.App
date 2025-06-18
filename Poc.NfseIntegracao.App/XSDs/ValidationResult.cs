namespace Poc.NfseIntegracao.App.XSDs
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; } = [];

        public List<string> Warnings { get; set; } = [];

        public override string ToString()
        {
            var result = $"Validação: {(IsValid ? "VÁLIDA" : "INVÁLIDA")}\n";

            if (Errors.Count > 0)
            {
                result += $"Erros ({Errors.Count}):\n";
                foreach (var error in Errors)
                {
                    result += $"  - {error}\n";
                }
            }

            if (Warnings.Count <= 0) return result;
            result += $"Avisos ({Warnings.Count}):\n";
            foreach (var warning in Warnings)
            {
                result += $"  - {warning}\n";
            }

            return result;
        }
    }
}
