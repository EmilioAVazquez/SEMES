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
 * Wearhouse Entity
 * @export
 * @interface Wearhouse
 */
export interface Wearhouse {
    /**
     * @type {string}
     * @memberof Wearhouse
     */
    wearhouseId: string;
    /**
     * @type {string}
     * @memberof Wearhouse
     */
    name: string;
    /**
     * Address given by a geolocation string
     * @type {string}
     * @memberof Wearhouse
     */
    address?: string | null;
}
