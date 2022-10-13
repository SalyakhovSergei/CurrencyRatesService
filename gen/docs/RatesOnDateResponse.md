

# RatesOnDateResponse

Список официальных курсов валют на заданную дату, устанавливаемых ежедневно.
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**date** | **LocalDate** | Дата установления курса (может отличатся от запрашиваемой если на запрашиваемою дату курс не устанавливался). |  [optional]
**rates** | [**List&lt;RateResponse&gt;**](RateResponse.md) | Список курсов валют. |  [optional]



