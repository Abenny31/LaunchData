import React from 'react';

const modalStyle = {
    position: 'fixed',
    top: 0,
    left: 0,
    width: '100vw',
    height: '100vh',
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    zIndex: 1000
};

const contentStyle = {
    backgroundColor: 'white',
    padding: '2rem',
    borderRadius: '8px',
    maxWidth: '600px',
    width: '90%',
    maxHeight: '80vh',
    overflowY: 'auto',
    position: 'relative'
};

const closeButtonStyle = {
    position: 'absolute',
    top: '10px',
    right: '10px',
    fontSize: '20px',
    cursor: 'pointer',
    border: 'none',
    background: 'none'
};

const Modal = ({ isOpen, onClose, children }) => {
    if (!isOpen) return null;

    return (
        <div style={modalStyle} onClick={onClose}>
            <div style={contentStyle} onClick={e => e.stopPropagation()}>
                <button style={{
                    position: 'absolute',
                    top: '10px',
                    right: '10px',
                    fontSize: '20px',
                    cursor: 'pointer',
                    border: 'none',
                    background: 'none',
                    color: 'red',
                    fontWeight: 'bold'
                }}
                    onClick={onClose}
                >
                    X
                </button>
                {children}
            </div>
        </div>
    );
};

export default Modal;