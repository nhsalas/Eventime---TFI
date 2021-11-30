using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BackUrls
    {
        public string failure { get; set; }
        public string pending { get; set; }
        public string success { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string category_id { get; set; }
        public string currency_id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
    }

    public class Metadata
    {
    }

    public class Phone
    {
        public string area_code { get; set; }
        public string number { get; set; }
    }

    public class Address
    {
        public string zip_code { get; set; }
        public string street_name { get; set; }
        public object street_number { get; set; }
    }

    public class Identification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Payer
    {
        public Phone phone { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public Identification identification { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public object date_created { get; set; }
        public object last_purchase { get; set; }
    }

    public class ExcludedPaymentMethod
    {
        public string id { get; set; }
    }

    public class ExcludedPaymentType
    {
        public string id { get; set; }
    }

    public class PaymentMethods
    {
        public object default_card_id { get; set; }
        public object default_payment_method_id { get; set; }
        public List<ExcludedPaymentMethod> excluded_payment_methods { get; set; }
        public List<ExcludedPaymentType> excluded_payment_types { get; set; }
        public object installments { get; set; }
        public object default_installments { get; set; }
    }

    public class RedirectUrls
    {
        public string failure { get; set; }
        public string pending { get; set; }
        public string success { get; set; }
    }

    public class ReceiverAddress
    {
        public string zip_code { get; set; }
        public string street_name { get; set; }
        public object street_number { get; set; }
        public string floor { get; set; }
        public string apartment { get; set; }
        public object city_name { get; set; }
        public object state_name { get; set; }
        public object country_name { get; set; }
    }

    public class Shipments
    {
        public object default_shipping_method { get; set; }
        public ReceiverAddress receiver_address { get; set; }
    }

    public class Root
    {
        public string additional_info { get; set; }
        public string auto_return { get; set; }
        public BackUrls back_urls { get; set; }
        public bool binary_mode { get; set; }
        public string client_id { get; set; }
        public int collector_id { get; set; }
        public object coupon_code { get; set; }
        public object coupon_labels { get; set; }
        public DateTime date_created { get; set; }
        public object date_of_expiration { get; set; }
        public object expiration_date_from { get; set; }
        public object expiration_date_to { get; set; }
        public bool expires { get; set; }
        public string external_reference { get; set; }
        public string id { get; set; }
        public string init_point { get; set; }
        public object internal_metadata { get; set; }
        public List<Item> items { get; set; }
        public string marketplace { get; set; }
        public int marketplace_fee { get; set; }
        public Metadata metadata { get; set; }
        public object notification_url { get; set; }
        public string operation_type { get; set; }
        public Payer payer { get; set; }
        public PaymentMethods payment_methods { get; set; }
        public object processing_modes { get; set; }
        public object product_id { get; set; }
        public RedirectUrls redirect_urls { get; set; }
        public string sandbox_init_point { get; set; }
        public string site_id { get; set; }
        public Shipments shipments { get; set; }
        public object total_amount { get; set; }
        public object last_updated { get; set; }
    }


}
