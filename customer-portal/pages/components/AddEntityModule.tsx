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
  
      // Handle the response data
      console.log(response.data);
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

  const closeStyle = {
    ...companyStyle,
    color: "#FF0000",
  };

  const addStyle = {
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
        style={companyStyle}
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
          <Text id="modal-title" style= {companyStyleInter} size={18}>
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
            onChange={(e) => setCompanyName(e.target.value)}
            style={companyNameStyle}
          />
        </Modal.Body>
        <Modal.Footer>
          <Row justify="flex-end">
            <Button style={closeStyle} onPress={closeHandler}>
              Close
            </Button>
            <Button 
              style={addStyle}
              onPress={handleAddCompany}>
              Add
            </Button>
          </Row>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
