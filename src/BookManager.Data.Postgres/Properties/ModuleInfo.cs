using GreenDonut;
using HotChocolate;

[assembly: Module("PostgresData")]
[assembly: DataLoaderDefaults(
    AccessModifier = DataLoaderAccessModifier.PublicInterface,
    ServiceScope = DataLoaderServiceScope.DataLoaderScope)]