using AdminService.DataModel;
using StackExchange.Redis;
using System.Reflection;
using Type = System.Type;

namespace CartServicePOC.Extensions
{
    public static class RedisExtension
    {
        public static HashEntry[] ToHashEntries(this object obj)
        {
            try
            {
                PropertyInfo[] properties = obj.GetType().GetProperties();
                return properties
                    .Where(x => x.GetValue(obj) != null) // <-- PREVENT NullReferenceException
                    .Select(property => new HashEntry(property.Name, property.GetValue(obj)
                    .ToString())).ToArray();
            }
            catch (Exception ex)
            {

            }
            return new HashEntry[0];
        }

        public static T ConvertFromRedis<T>(HashEntry[] hashEntries)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                var obj = Activator.CreateInstance(typeof(T));
                foreach (var property in properties)
                {
                    HashEntry entry = hashEntries.FirstOrDefault(g => g.Name.ToString().Equals(property.Name));
                    if (entry.Equals(new HashEntry())) continue;
                    switch (property.PropertyType)
                    {
                        case Type guidType when guidType == typeof(Guid):
                            property.SetValue(obj, Guid.Parse(entry.Value.ToString()));
                            break;
                        case Type dobleType when dobleType == typeof(double):
                            property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                            break;
                        case Type stringType when stringType == typeof(string):
                            property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                            break;
                        case Type intType when intType == typeof(int):
                            property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                            break;
                        case Type configurationType when configurationType == typeof(ConfigurationTypeEnum):
                            property.SetValue(obj, Convert.ChangeType(Enum.Parse(property.PropertyType, entry.Value.ToString()), property.PropertyType));
                            break;
                        case Type billingFrequencyType when billingFrequencyType == typeof(BillingFrequency):
                            property.SetValue(obj, Convert.ChangeType(Enum.Parse(property.PropertyType, entry.Value.ToString()), property.PropertyType));
                            break;
                        case Type billingRuleType when billingRuleType == typeof(BillingRule):
                            property.SetValue(obj, Convert.ChangeType(Enum.Parse(property.PropertyType, entry.Value.ToString()), property.PropertyType));
                            break;
                        case Type chargeType when chargeType == typeof(ChargeType):
                            property.SetValue(obj, Convert.ChangeType(Enum.Parse(property.PropertyType, entry.Value.ToString()), property.PropertyType));
                            break;
                        case Type autoRenewalType when autoRenewalType == typeof(AutoRenewalType):
                            property.SetValue(obj, Convert.ChangeType(Enum.Parse(property.PropertyType, entry.Value.ToString()), property.PropertyType));
                            break;
                        default:
                            break;
                    }

                }
                return (T)obj;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }


}
