const TransactionHistoryReducer = ( state = [], action: { Type: any; }) => {
    switch(action.Type){
        case 'Update':
            return state;
        default:
            return state;
    }
}
export default TransactionHistoryReducer;