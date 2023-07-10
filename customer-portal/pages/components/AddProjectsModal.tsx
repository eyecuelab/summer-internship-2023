import React, { useState } from "react";
import { Modal, Button, Text, Input, Row } from "@nextui-org/react";

export default function AddProjectModal() {
  const [visible, setVisible] = useState(false);
  const [projectName, setProjectName] = useState("");
  const [githubLink, setGithubLink] = useState("");
  const [trelloLink, setTrelloLink] = useState("");

  const handleOpen = () => setVisible(true);
  const handleClose = () => setVisible(false);

  const handleAddProject = () => {
    // Perform your API request here using the input values
    console.log("Project Name:", projectName);
    console.log("GitHub Link:", githubLink);
    console.log("Trello Link:", trelloLink);

    // Reset input fields
    setProjectName("");
    setGithubLink("");
    setTrelloLink("");

    // Close the modal
    handleClose();
  };

  return (
    <div>
      <Button
        shadow
        onPress={handleOpen}
        style={{ color: "black" }}
      >Add Project</Button>
      <Modal
        open={visible}
        onClose={handleClose}
        aria-labelledby="modal-title"
        closeButton
      >
        <Modal.Header>
          <Text id="modal-title" size={18}>
            Add Project
          </Text>
        </Modal.Header>
        <Modal.Body>
          <Input
            clearable
            bordered
            fullWidth
            color="primary"
            size="lg"
            placeholder="Project Name"
            value={projectName}
            onChange={(e) => setProjectName(e.target.value)}
          />
          <Input
            clearable
            bordered
            fullWidth
            color="primary"
            size="lg"
            placeholder="GitHub Link"
            value={githubLink}
            onChange={(e) => setGithubLink(e.target.value)}
          />
          <Input
            clearable
            bordered
            fullWidth
            color="primary"
            size="lg"
            placeholder="Trello Link"
            value={trelloLink}
            onChange={(e) => setTrelloLink(e.target.value)}
          />
        </Modal.Body>
        <Modal.Footer>
          <Row justify="flex-end">
            <Button flat color="error" onPress={handleClose}>
              Close
            </Button>
            <Button 
                style={{ color: "black" }}
                onPress={handleAddProject}>
              Add
            </Button>
          </Row>
        </Modal.Footer>
      </Modal>
    </div>
  );
}