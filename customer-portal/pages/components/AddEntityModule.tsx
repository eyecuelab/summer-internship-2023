import React, { useState } from "react";
import { Modal, Button, Text, Input, Row, Checkbox } from "@nextui-org/react";

export default function AddEntityModule() {
  const [visible, setVisible] = useState(false);
  const [companyName, setCompanyName] = useState("");

  const handler = () => setVisible(true);
  const closeHandler = () => setVisible(false);

  const handleAddCompany = () => {
    // Perform your API request here using the companyName value
    console.log("Company Name:", companyName);

    // Reset input field
    setCompanyName("");

    // Close the modal
    closeHandler();
  };

  return (
    <div>
      <Button
        shadow
        onPress={handler}
        style={{ color: "black" }}
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
          <Text id="modal-title" size={18}>
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
          />
        </Modal.Body>
        <Modal.Footer>
          <Row justify="flex-end">
            <Button flat color="error" onPress={closeHandler}>
              Close
            </Button>
            <Button 
              style={{ color: "black" }}
              onPress={handleAddCompany}>
              Add
            </Button>
          </Row>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
