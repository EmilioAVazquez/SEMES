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
 * Supplier Entity
 * @export
 * @interface Supplier
 */
export interface Supplier {
    /**
     * @type {string}
     * @memberof Supplier
     */
    supplierId: string;
    /**
     * First Name
     * @type {string}
     * @memberof Supplier
     */
    firstName: string;
    /**
     * Last Name
     * @type {string}
     * @memberof Supplier
     */
    lastName: string;
    /**
     * Phone number in integer with no special characters.  Leaving space with 0 for special code.
     * @type {number}
     * @memberof Supplier
     */
    phoneNumber: number;
    /**
     * @type {string}
     * @memberof Supplier
     */
    email: string;
    /**
     * Address given by a geolocation string
     * @type {string}
     * @memberof Supplier
     */
    address?: string | null;
}
