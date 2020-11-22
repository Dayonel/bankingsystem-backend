using System;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.VM.Request
{
    public class WithdrawVM
    {
        [Range(1, int.MaxValue, ErrorMessage = "Invalid account id.")]
        public int AccountId { get; set; }
        [Range(float.Epsilon, float.MaxValue, ErrorMessage = "Invalid amount.")]
        public float Amount { get; set; }
    }
}
