/*
 * Axioma OMNI currency rates REST API
 * Получение информации по официальным курсам валют ЦБ и курсам металлов. Промышленный сервис находится по адресу https://, тестовый сервис - по адресу https://ingress-ds1-genr01-fxrt-dev1.apps.ds1-genr01.corp.dev.vtb/fxrates-cbr/v1/api
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: vizgalov@vtb.ru
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package org.openapitools.client.model;

import java.util.Objects;
import java.util.Arrays;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import java.io.IOException;
import java.math.BigDecimal;
import org.openapitools.client.model.CurrencyResponse;

/**
 * Информация о курсе валюты на заданную дату.
 */
@ApiModel(description = "Информация о курсе валюты на заданную дату.")
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", date = "2022-07-07T18:13:29.328552800+10:00[Asia/Vladivostok]")
public class RateResponse {
  public static final String SERIALIZED_NAME_CURRENCY = "currency";
  @SerializedName(SERIALIZED_NAME_CURRENCY)
  private CurrencyResponse currency;

  public static final String SERIALIZED_NAME_PRICE = "price";
  @SerializedName(SERIALIZED_NAME_PRICE)
  private BigDecimal price;

  public static final String SERIALIZED_NAME_SCALE = "scale";
  @SerializedName(SERIALIZED_NAME_SCALE)
  private Integer scale;


  public RateResponse currency(CurrencyResponse currency) {
    
    this.currency = currency;
    return this;
  }

   /**
   * Get currency
   * @return currency
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "")

  public CurrencyResponse getCurrency() {
    return currency;
  }


  public void setCurrency(CurrencyResponse currency) {
    this.currency = currency;
  }


  public RateResponse price(BigDecimal price) {
    
    this.price = price;
    return this;
  }

   /**
   * Значение курса.
   * minimum: 0
   * maximum: 1.0E+14
   * @return price
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "0.1", value = "Значение курса.")

  public BigDecimal getPrice() {
    return price;
  }


  public void setPrice(BigDecimal price) {
    this.price = price;
  }


  public RateResponse scale(Integer scale) {
    
    this.scale = scale;
    return this;
  }

   /**
   * Номинал.
   * minimum: 0
   * maximum: 1000000000
   * @return scale
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "100000", value = "Номинал.")

  public Integer getScale() {
    return scale;
  }


  public void setScale(Integer scale) {
    this.scale = scale;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    RateResponse rateResponse = (RateResponse) o;
    return Objects.equals(this.currency, rateResponse.currency) &&
        Objects.equals(this.price, rateResponse.price) &&
        Objects.equals(this.scale, rateResponse.scale);
  }

  @Override
  public int hashCode() {
    return Objects.hash(currency, price, scale);
  }


  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class RateResponse {\n");
    sb.append("    currency: ").append(toIndentedString(currency)).append("\n");
    sb.append("    price: ").append(toIndentedString(price)).append("\n");
    sb.append("    scale: ").append(toIndentedString(scale)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }

}

