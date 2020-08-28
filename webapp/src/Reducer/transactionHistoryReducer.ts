import {Transaction} from '../SemesApi';


const transactionHistoryReducer = ( state: Array<Transaction> = [], action:  any) => {
    switch(action.type){
        case "UPDATE_TRANSACTIONS_SUCCESS":
            return action.payload;
        default:
            return state;
    }
}
export default transactionHistoryReducer;