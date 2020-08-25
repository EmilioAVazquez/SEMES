// tslint:disable
/**
 * ToDo API
 * A simple example ASP.NET Core Web API
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

/**
 * @export
 * @interface WeatherForecast
 */
export interface WeatherForecast {
    /**
     * @type {string}
     * @memberof WeatherForecast
     */
    date?: string;
    /**
     * @type {number}
     * @memberof WeatherForecast
     */
    temperatureC?: number;
    /**
     * @type {number}
     * @memberof WeatherForecast
     */
    readonly temperatureF?: number;
    /**
     * @type {string}
     * @memberof WeatherForecast
     */
    summary?: string | null;
}