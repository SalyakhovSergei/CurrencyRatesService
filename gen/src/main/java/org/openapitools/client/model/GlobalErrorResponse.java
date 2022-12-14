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

/**
 * Сообщение об ошибке, возникшей в сервисе курсов валют.
 */
@ApiModel(description = "Сообщение об ошибке, возникшей в сервисе курсов валют.")
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", date = "2022-07-07T18:13:29.328552800+10:00[Asia/Vladivostok]")
public class GlobalErrorResponse {
  public static final String SERIALIZED_NAME_STATUS = "status";
  @SerializedName(SERIALIZED_NAME_STATUS)
  private Integer status;

  public static final String SERIALIZED_NAME_MESSAGE = "message";
  @SerializedName(SERIALIZED_NAME_MESSAGE)
  private String message;

  public static final String SERIALIZED_NAME_TIMESTAMP = "timestamp";
  @SerializedName(SERIALIZED_NAME_TIMESTAMP)
  private String timestamp;


  public GlobalErrorResponse status(Integer status) {
    
    this.status = status;
    return this;
  }

   /**
   * Код состояния HTTP.
   * minimum: 0
   * maximum: 999
   * @return status
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Код состояния HTTP.")

  public Integer getStatus() {
    return status;
  }


  public void setStatus(Integer status) {
    this.status = status;
  }


  public GlobalErrorResponse message(String message) {
    
    this.message = message;
    return this;
  }

   /**
   * Сообщение об ошибке.
   * @return message
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Сообщение об ошибке.")

  public String getMessage() {
    return message;
  }


  public void setMessage(String message) {
    this.message = message;
  }


  public GlobalErrorResponse timestamp(String timestamp) {
    
    this.timestamp = timestamp;
    return this;
  }

   /**
   * Дата и время возникновения ошибки.
   * @return timestamp
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "2000-12-31T08:59:32.39475", value = "Дата и время возникновения ошибки.")

  public String getTimestamp() {
    return timestamp;
  }


  public void setTimestamp(String timestamp) {
    this.timestamp = timestamp;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    GlobalErrorResponse globalErrorResponse = (GlobalErrorResponse) o;
    return Objects.equals(this.status, globalErrorResponse.status) &&
        Objects.equals(this.message, globalErrorResponse.message) &&
        Objects.equals(this.timestamp, globalErrorResponse.timestamp);
  }

  @Override
  public int hashCode() {
    return Objects.hash(status, message, timestamp);
  }


  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class GlobalErrorResponse {\n");
    sb.append("    status: ").append(toIndentedString(status)).append("\n");
    sb.append("    message: ").append(toIndentedString(message)).append("\n");
    sb.append("    timestamp: ").append(toIndentedString(timestamp)).append("\n");
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

