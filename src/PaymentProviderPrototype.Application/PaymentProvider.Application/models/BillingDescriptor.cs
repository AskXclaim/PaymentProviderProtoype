namespace PaymentProvider.Application.models;

public class BillingDescriptor
{
    //string <= 25 characters
    //A description for the payment, which will be displayed on the customer's card statement. Only applicable for card payments.
    public string Name { get; set; }
    //string [ 1 .. 13 ] characters
    //The city from which the payment originated. Only applicable for card payments.
    public string City { get; set; }
    	
    //string <= 50 characters
    //The reference to display on the customer's bank statement. Required for payouts to bank accounts.
    public string Reference { get; set; }
}