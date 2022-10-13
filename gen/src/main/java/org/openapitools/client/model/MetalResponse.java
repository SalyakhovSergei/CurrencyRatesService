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

/**
 * Информация о цене металла на заданную дату.
 */
@ApiModel(description = "Информация о цене металла на заданную дату.")
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", date = "2022-07-07T18:13:29.328552800+10:00[Asia/Vladivostok]")
public class MetalResponse {
  public static final String SERIALIZED_NAME_ALPHA_CODE = "alphaCode";
  @SerializedName(SERIALIZED_NAME_ALPHA_CODE)
  private String alphaCode;

  public static final String SERIALIZED_NAME_NAME = "name";
  @SerializedName(SERIALIZED_NAME_NAME)
  private String name;

  public static final String SERIALIZED_NAME_PRICE = "price";
  @SerializedName(SERIALIZED_NAME_PRICE)
  private BigDecimal price;


  public MetalResponse alphaCode(String alphaCode) {
    
    this.alphaCode = alphaCode;
    return this;
  }

   /**
   * Код по классификатору клиринговых валют
   * @return alphaCode
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Код по классификатору клиринговых валют")

  public String getAlphaCode() {
    return alphaCode;
  }


  public void setAlphaCode(String alphaCode) {
    this.alphaCode = alphaCode;
  }


  public MetalResponse name(String name) {
    
    this.name = name;
    return this;
  }

   /**
   * Наименование драгоценного металла
   * @return name
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Наименование драгоценного металла")

  public String getName() {
    return name;
  }


  public void setName(String name) {
    this.name = name;
  }


  public MetalResponse price(BigDecimal price) {
    
    this.price = price;
    return this;
  }

   /**
   * Цена в рублях за 1 грамм.
   * minimum: 0
   * maximum: 1.0E+14
   * @return price
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Цена в рублях за 1 грамм.")

  public BigDecimal getPrice() {
    return price;
  }


  public void setPrice(BigDecimal price) {
    this.price = price;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    MetalResponse metalResponse = (MetalResponse) o;
    return Objects.equals(this.alphaCode, metalResponse.alphaCode) &&
        Objects.equals(this.name, metalResponse.name) &&
        Objects.equals(this.price, metalResponse.price);
  }

  @Override
  public int hashCode() {
    return Objects.hash(alphaCode, name, price);
  }


  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class MetalResponse {\n");
    sb.append("    alphaCode: ").append(toIndentedString(alphaCode)).append("\n");
    sb.append("    name: ").append(toIndentedString(name)).append("\n");
    sb.append("    price: ").append(toIndentedString(price)).append("\n");
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

