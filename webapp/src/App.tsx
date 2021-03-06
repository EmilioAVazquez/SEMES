import React from 'react';
import './App.css';
import Button from '@material-ui/core/Button';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import MenuIcon from '@material-ui/icons/Menu';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import TransactionFeature from "./EmployeeView/TransactionFeature";
import ClientFeature from "./EmployeeView/ClientFeature";
import TransactionHistory from "./EmployeeView/TransactionHistory";

function App() {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  }; 

  return (
    <Box p={2} >
      <Button color = 'primary' variant="contained" aria-controls="simple-menu" aria-haspopup="true" onClick={handleClick}>
        <MenuIcon />
      </Button>
      <Menu
        id="simple-menu"
        anchorEl={anchorEl}
        keepMounted
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        <MenuItem onClick={handleClose}>Profile</MenuItem>
        <MenuItem onClick={handleClose}>My account</MenuItem>
        <MenuItem onClick={handleClose}>Logout</MenuItem>
      </Menu>
      <Box p={2} >
        <Typography variant="h3" gutterBottom>
          Hi Emilio!
        </Typography>
      </Box>
      
      <Box p={1} >
        <TransactionFeature></TransactionFeature>
      </Box>
      
      <Box p={1} >
        <ClientFeature></ClientFeature>
      </Box>
      <Box p={2} >
        <Typography variant="h5" gutterBottom>
          Past transactions
        </Typography>
      </Box>
      <TransactionHistory></TransactionHistory>
    </Box>
  );
}

export default App;
