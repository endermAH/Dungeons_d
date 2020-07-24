# Languages scripts
## Languages.cs
Multi-languages support 

### Struct `WeaponDescription`
Fields: TranslatableString Name, TranslatableString Description;
static TranslatableString Damage/AttackSpeed/AttackRadius

| Constructor       | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| WeaponDescription | public        | <ui><li>TranslatableString `name`</li><li>TranslatableString `description`</li></ui>| Gets weapon's name and description as a TranslatableString| -              | 


### Class `Languages`
Fields: string English, string Russian; string[] SupportedLanguages

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 

## TranslatableString.cs
Translate string from one lang to other

### Struct `TranslatableString`
Field: string[] Text - array of string for translate

| Constructor       | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| TranslatableString| public        | string[] `text` - multi-lang array of string| Get multilingual dictionary| -              | 
