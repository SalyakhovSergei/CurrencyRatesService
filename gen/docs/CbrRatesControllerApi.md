# CbrRatesControllerApi

All URIs are relative to *https://k3-tyki-app401lv.vtb24.ru/api/CIB/FXRT/currency/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**dailyFxrates**](CbrRatesControllerApi.md#dailyFxrates) | **GET** /cbr/daily_fxrates | Получение информации по курсам валют ЦБ
[**dailyFxratesLatestDate**](CbrRatesControllerApi.md#dailyFxratesLatestDate) | **GET** /cbr/daily_fxrates/latest_date | Получение последней даты курсов валют ЦБ


<a name="dailyFxrates"></a>
# **dailyFxrates**
> RatesOnDateResponse dailyFxrates(date)

Получение информации по курсам валют ЦБ

Получение информации по курсам валют ЦБ.

### Example
```java
// Import classes:
import org.openapitools.client.ApiClient;
import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.models.*;
import org.openapitools.client.api.CbrRatesControllerApi;

public class Example {
  public static void main(String[] args) {
    ApiClient defaultClient = Configuration.getDefaultApiClient();
    defaultClient.setBasePath("https://k3-tyki-app401lv.vtb24.ru/api/CIB/FXRT/currency/v1");

    CbrRatesControllerApi apiInstance = new CbrRatesControllerApi(defaultClient);
    LocalDate date = new LocalDate(); // LocalDate | Дата получения курса.
    try {
      RatesOnDateResponse result = apiInstance.dailyFxrates(date);
      System.out.println(result);
    } catch (ApiException e) {
      System.err.println("Exception when calling CbrRatesControllerApi#dailyFxrates");
      System.err.println("Status code: " + e.getCode());
      System.err.println("Reason: " + e.getResponseBody());
      System.err.println("Response headers: " + e.getResponseHeaders());
      e.printStackTrace();
    }
  }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **date** | **LocalDate**| Дата получения курса. | [optional]

### Return type

[**RatesOnDateResponse**](RatesOnDateResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | Успешное получение информации по курсам валют ЦБ. |  -  |
**400** | Неверный параметр запроса. |  -  |
**401** | Пользователь не авторизован. |  -  |
**404** | Неверный адрес запроса. |  -  |
**500** | Внутренняя ошибка. |  -  |

<a name="dailyFxratesLatestDate"></a>
# **dailyFxratesLatestDate**
> LatestRatesDateResponse dailyFxratesLatestDate()

Получение последней даты курсов валют ЦБ

Получение последней даты курсов валют ЦБ.

### Example
```java
// Import classes:
import org.openapitools.client.ApiClient;
import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.models.*;
import org.openapitools.client.api.CbrRatesControllerApi;

public class Example {
  public static void main(String[] args) {
    ApiClient defaultClient = Configuration.getDefaultApiClient();
    defaultClient.setBasePath("https://k3-tyki-app401lv.vtb24.ru/api/CIB/FXRT/currency/v1");

    CbrRatesControllerApi apiInstance = new CbrRatesControllerApi(defaultClient);
    try {
      LatestRatesDateResponse result = apiInstance.dailyFxratesLatestDate();
      System.out.println(result);
    } catch (ApiException e) {
      System.err.println("Exception when calling CbrRatesControllerApi#dailyFxratesLatestDate");
      System.err.println("Status code: " + e.getCode());
      System.err.println("Reason: " + e.getResponseBody());
      System.err.println("Response headers: " + e.getResponseHeaders());
      e.printStackTrace();
    }
  }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**LatestRatesDateResponse**](LatestRatesDateResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | Успешное получение последней даты курсов валют ЦБ. |  -  |
**401** | Пользователь не авторизован. |  -  |
**404** | Неверный адрес запроса. |  -  |
**500** | Внутренняя ошибка. |  -  |

