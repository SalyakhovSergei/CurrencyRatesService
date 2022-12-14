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


package org.openapitools.client.auth;

import org.openapitools.client.Pair;

import java.util.Map;
import java.util.List;

public interface Authentication {
    /**
     * Apply authentication settings to header and query params.
     *
     * @param queryParams List of query parameters
     * @param headerParams Map of header parameters
     * @param cookieParams Map of cookie parameters
     */
    void applyToParams(List<Pair> queryParams, Map<String, String> headerParams, Map<String, String> cookieParams);
}
