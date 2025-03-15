using Domain.Enums;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transactions
{
    public class Transaction : Entity
    {
        public Transaction(TransactionType type, string info)
        {
            Type = type;
            Information = info;
        }
        public Transaction() { }
        public Transaction(TransactionType type,
                           Entity entity, BankAccount? RecipientBankAccount = null, BankAccount? ReceiverBankAccount = null)
        {
            Type = type;
            switch (Type)
            {
                case TransactionType.None:
                    Information = "";
                    break;
                case TransactionType.BACreation:
                    Information = entity is BankAccount ?
                    GetBankAccountCreationInfo(entity as BankAccount) :
                    GetRCBAInfo(entity as RCBA);

                    break;
                case TransactionType.Transfer:
                    Information = GetTransactionInfo(entity as Transfer, RecipientBankAccount, ReceiverBankAccount);
                    break;
            }
        }
        private string GetBankAccountCreationInfo(BankAccount BA)
        {
            return $"Создание банковского счета. Статус: Одобрено" +
                   $"Название счета: {BA.AccountName}.\n" +
                   $"Номер счета: {BA.AccountNumber}.\n" +
                   $"Валюта: {BA.Currency}.\n" +
                   $"Статус: {BA.Status}.\n" +
                   $"ID пользователя: {BA.UserId}.\n" +
                   $"ID банка: {BA.BankId}.\n" +
                   $"Время создания: {BA.CreatedAt:dd/MM/yyyy HH:mm:ss}.";
        }
        private string GetRCBAInfo(RCBA rcba)
        {
            return $"Создание банковского счета. Статус: Отклонено.\n" +
                   $"Название счета: {rcba.AccountName}.\n" +
                   $"Валюта: {rcba.Currency}.\n" +
                   $"ID пользователя: {rcba.UserId}.\n" +
                   $"ID банка: {rcba.BankId}.\n" +
                   $"Время запроса: {rcba.CreatedAt:dd/MM/yyyy HH:mm:ss}.";
        }

        private string GetTransactionInfo(Transfer transfer, BankAccount RecipientBankAccount, BankAccount ReceiverBankAccount)
        {
            string recipientInfo = RecipientBankAccount != null
                ? $"Счет отправителя: {RecipientBankAccount.AccountNumber}.\nБаланс: {RecipientBankAccount.Balance} {RecipientBankAccount.Currency}.\n"
                : "Счет отправителя: Не указан.\n";

            string receiverInfo = ReceiverBankAccount != null
                ? $"Счет получателя: {ReceiverBankAccount.AccountNumber}.\nБаланс: {ReceiverBankAccount.Balance} {ReceiverBankAccount.Currency}.\n"
                : "Счет получателя: Не указан.\n";

            return $"Перевод средств.\n" +
                   $"{recipientInfo}.\n" +
                   $"{receiverInfo}.\n" +
                   $"Сумма в рублях: {transfer.Amount}.\n" +
                   $"Статус: {(transfer.IsCancelled ? "Отменен" : "Выполнен")}.\n" +
                   $"Дата: {transfer.Date:dd/MM/yyyy HH:mm:ss}.";
        }
        public TransactionType Type { get; set; }
        public string Information {  get; set; }
    }
}
