import {Transaction} from '../SemesApi';


const transactionHistoryReducer = ( state: Array<Transaction> = [], action:  any) => {
    switch(action.Type){
        case 'UPDATE_TRANSACTIONS_SUCCESS':
            return action.payload.user;
        default:
            return state;
    }
}
export default transactionHistoryReducer;