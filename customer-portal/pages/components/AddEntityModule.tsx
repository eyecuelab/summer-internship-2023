import React, { useState } from "react";
import { Modal, Button, Text, Input, Row, Checkbox } from "@nextui-org/react";
import axios from "axios";

export default function AddEntityModule() {
  const [visible, setVisible] = useState(false);
  const [companyName, setCompanyName] = useState("");

  const handler = () => setVisible(true);
  const closeHandler = () => setVisible(false);

  const handleAddCompany = async () => {
    try {
      const url = 'https://localhost:7243/api/entities';
      const payload = {
        companyName: companyName
      };
  
      const response = await axios.post(url, payload);
  
    } catch (error) {
      // Handle error
      console.error(error);
    }

    // Reset input field
    setCompanyName("");

    // Close the modal
    closeHandler();
  };

  const companyStyle = {
    fontFamily: "Rasa",
    fontWeight: 600,
    fontSize: "18px",
    lineHeight: "40.8px",
    color: "#404040",
};

const companyStyleInter = {
    ...companyStyle,
    fontWeight: 400,
    fontSize: "24px",
};

const closeCompanyStyle = {
    ...companyStyle,
    color: "#FF0000",
};

const addCompanyStyle = {
    ...companyStyle
};

const companyNameStyle = {
    ...companyStyle,
    
};

  return (
    <div>
      <Button
        shadow
        onPress={handler}
        // style={{
        //   position: "absolute",
        //   bottom: "40px", // You can adjust this value as needed
        //   left: "10%",
        //   transform: "translateX(-50%)",
        //   zIndex: 1,
        //   boxShadow: "0 2px 4px rgba(0, 0, 0, 0.2)",
        //   borderRadius: "999px",
        //   padding: "8px 12px",
        //   backgroundColor: "#E6E6E6",
        //   fontFamily: "Rasa",
        //   fontSize: "20px",
        //   cursor: "pointer",
        // }}
        style={{ 
            position: "absolute",
            bottom: "40px",
            left: "10%",
            transform: "translateX(-50%)",
            zIndex: 1,
            borderRadius: "999px",
            backgroundColor: "#E6E6E6",
            color: "#404040",
            padding: "8px 12px",
            fontFamily: "Rasa",
            fontSize: "20px",
            cursor: "pointer",
        }}
      >
        Add Company
        
      </Button>
      <Modal
        closeButton
        aria-labelledby="modal-title"
        open={visible}
        onClose={closeHandler}
      >
        <Modal.Header>
          <Text id="modal-title" style = {companyStyleInter} size={18}>
            Add Company
          </Text>
        </Modal.Header>
        <Modal.Body>
          <Input
            clearable
            bordered
            fullWidth
            color="primary"
            size="lg"
            placeholder="Company Name"
            value={companyName}
            style={companyNameStyle}
            onChange={(e) => setCompanyName(e.target.value)}
          />
        </Modal.Body>
        <Modal.Footer>
          <Row justify="flex-end">
            <Button style={closeCompanyStyle} onPress={closeHandler}>
              Close
            </Button>
            <Button 
              style={ addCompanyStyle }
              onPress={handleAddCompany}>
              Add
            </Button>
          </Row>
          
        </Modal.Footer>
      </Modal>
    </div>
  );
}
