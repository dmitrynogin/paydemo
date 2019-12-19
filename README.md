# Payment Demo
Demonstrate how we can migrate from one payment provider (e.g. E-xact) to another (e.g. Stripe) by implementing an provider specific `BillingId` (e.g. in the form of Account ID for E-xact and Customer ID for Stripe). The  default payment provider for new customers is one that implements `IMainPaymentProvider`.
