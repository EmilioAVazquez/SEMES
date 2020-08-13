import React from 'react';
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
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

function TransactionHistory() {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  function generate(element: React.ReactElement) {
    return [0, 1, 2, 3, 4, 5, 6].map((value) =>
      React.cloneElement(element, {
        key: value,
      }),
    );
  }
  

  return (
      <>
        <List component="nav" aria-label="secondary mailbox folders">
        {generate(
            <ListItem >
            <ListItemText primary="12:01 pm Client: None Items: 2water" />
            <ListItemSecondaryAction>
                        <IconButton edge="end" aria-label="delete" onClick={handleClickOpen}>
                        <DeleteIcon />
                        </IconButton>
                        <Dialog
                            open={open}
                            onClose={handleClose}
                            aria-labelledby="alert-dialog-title"
                            aria-describedby="alert-dialog-description"
                        >
                            <DialogTitle id="alert-dialog-title">{"Use Google's location service?"}</DialogTitle>
                            <DialogContent>
                            <DialogContentText id="alert-dialog-description">
                                Let Google help apps determine location. This means sending anonymous location data to
                                Google, even when no apps are running.
                            </DialogContentText>
                            </DialogContent>
                            <DialogActions>
                            <Button onClick={handleClose} color="primary">
                                Disagree
                            </Button>
                            <Button onClick={handleClose} color="primary" autoFocus>
                                Agree
                            </Button>
                            </DialogActions>
                        </Dialog>
            </ListItemSecondaryAction>
            </ListItem>)}
        </List>
    </>

  );
}

export default TransactionHistory;