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

import {
    Item,
    Transaction,
} from './';

/**
 * TransactionAction Entity
 * @export
 * @interface TransactionAction
 */
export interface TransactionAction {
    /**
     * List of Items associated with the given Transaction
     * @type {Array<Item>}
     * @memberof TransactionAction
     */
    items?: Array<Item> | null;
    /**
     * @type {Transaction}
     * @memberof TransactionAction
     */
    transaction?: Transaction;
}
