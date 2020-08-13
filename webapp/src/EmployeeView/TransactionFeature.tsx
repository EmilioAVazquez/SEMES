import React from 'react';
import Button from '@material-ui/core/Button';
import Drawer from '@material-ui/core/Drawer';
import TransactionForm from "./TransactionForm";
import Box from '@material-ui/core/Box';
import { allowedNodeEnvironmentFlags } from 'process';

function TransactionFeature(){
    const [state, setState] = React.useState({
        top: false,
    });

    const toggle = (open: boolean) => (
        event: React.KeyboardEvent | React.MouseEvent,
      )  => {
        setState({ ...state, ['top']: !open });
    };

    return(
            <>
                <Button color='primary' variant="contained" fullWidth ={true}  onClick={toggle(state['top'])}> 
                    Add Transaction  
                </Button>
                <Drawer  open={state['top']} anchor= {'top'} onClose={toggle(state['top'])}>
                    <Box p={2} >
                        <TransactionForm ></TransactionForm>
                    </Box>
                </Drawer>
            </>
    );
}

export default TransactionFeature;