import React from 'react';
import './App.css';
import Button from '@material-ui/core/Button';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import MenuIcon from '@material-ui/icons/Menu';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';

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
        <Button color = 'primary' variant="contained" fullWidth> Add Transaction </Button>
      </Box>
      <Box p={1} >
        <Button color = 'primary' variant="contained" fullWidth> Add Client </Button>
      </Box>
      <Box p={2} >
        <Typography variant="h5" gutterBottom>
          Past transactions
        </Typography>
      </Box>
      <List component="nav" aria-label="secondary mailbox folders">
        <ListItem >
          <ListItemText primary="12:01 pm Client: None Items: 2water" />
          <ListItemSecondaryAction>
                    <IconButton edge="end" aria-label="delete">
                      <DeleteIcon />
                    </IconButton>
        </ListItemSecondaryAction>
        </ListItem>
        <ListItem>
          <ListItemText primary="1:12 pm Client: Martha Items: 1water"  />
          <ListItemSecondaryAction>
                    <IconButton edge="end" aria-label="delete">
                      <DeleteIcon />
                    </IconButton>
        </ListItemSecondaryAction>
        </ListItem>
        <ListItem>
          <ListItemText primary="1:50 pm Client: Juan Items: 3water"  />
          <ListItemSecondaryAction>
                    <IconButton edge="end" aria-label="delete">
                      <DeleteIcon />
                    </IconButton>
        </ListItemSecondaryAction>
        </ListItem>
        <ListItem>
          <ListItemText primary="2:01 pm Client: Rocio Items: 1water"  />
          <ListItemSecondaryAction>
                    <IconButton edge="end" aria-label="delete">
                      <DeleteIcon />
                    </IconButton>
        </ListItemSecondaryAction>
        </ListItem>
      </List>
    </Box>
  );
}

export default App;
