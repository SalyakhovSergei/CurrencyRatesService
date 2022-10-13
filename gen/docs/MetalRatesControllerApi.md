# MetalRatesControllerApi

All URIs are relative to *https://k3-tyki-app401lv.vtb24.ru/api/CIB/FXRT/currency/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**metals**](MetalRatesControllerApi.md#metals) | **GET** /cbr/metal_prices | Получение информации по ценам драгоценных металлов


<a name="metals"></a>
# **metals**
> MetalsOnDateResponse metals(date)

Получение информации по ценам драгоценных металлов

Получение информации по ценам драгоценных металлов.

### Example
```java
// Import classes:
import org.openapitools.client.ApiClient;
import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.models.*;
import org.openapitools.client.api.MetalRatesControllerApi;

public class Example {
  public static void main(String[] args) {
    ApiClient defaultClient = Configuration.getDefaultApiClient();
    defaultClient.setBasePath("https://k3-tyki-app401lv.vtb24.ru/api/CIB/FXRT/currency/v1");

    MetalRatesControllerApi apiInstance = new MetalRatesControllerApi(defaultClient);
    LocalDate date = new LocalDate(); // LocalDate | Дата получения курса.
    try {
      MetalsOnDateResponse result = apiInstance.metals(date);
      System.out.println(result);
    } catch (ApiException e) {
      System.err.println("Exception when calling MetalRatesControllerApi#metals");
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

[**MetalsOnDateResponse**](MetalsOnDateResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | Успешное получение информации по курсам металлов ЦБ. |  -  |
**400** | Неверный параметр запроса. |  -  |
**401** | Пользователь не авторизован. |  -  |
**404** | Неверный адрес запроса. |  -  |
**500** | Внутренняя ошибка. |  -  |

