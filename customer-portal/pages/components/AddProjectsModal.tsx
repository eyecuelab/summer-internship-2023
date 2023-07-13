import React, { useState, useEffect } from "react";
import { Modal, Button, Text, Input, Row } from "@nextui-org/react";
import axios from "axios";

interface ProjectModalProps {
    currentEntity: Entity | null;
    onSelectedEntity: (selectedEntity: Entity | null) => void;
}

interface Entity {
    companyName: string;
    entityId: string;
}

export default function AddProjectModal({
    currentEntity,
    onSelectedEntity,
}: ProjectModalProps) {
    const [visible, setVisible] = useState(false);
    const [projectName, setProjectName] = useState("");

    const handleOpen = () => setVisible(true);
    const handleClose = () => setVisible(false);

    console.log("current entity in projectmodal ", currentEntity);

    const handleAddProject = async () => {
        try {
            const url = "https://localhost:7243/api/projects";
            const emailEntityPayload = {
                EntityId: currentEntity?.entityId,
                ProjectName: projectName,
            };

            const response = await axios.post(url, emailEntityPayload);

            // Handle the response data
            console.log(response.data);
        } catch (error) {
            // Handle error
            console.error(error);
        }

        // Reset input fields
        setProjectName("");

        // Close the modal
        handleClose();
    };

    

    return (
        <div>
            <Button shadow onPress={handleOpen} style={{ color: "black" }}>
                Add Project
            </Button>
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
                </Modal.Body>
                <Modal.Footer>
                    <Row justify="flex-end">
                        <Button flat color="error" onPress={handleClose}>
                            Close
                        </Button>
                        <Button
                            style={{ color: "black" }}
                            onPress={handleAddProject}
                        >
                            Add
                        </Button>
                    </Row>
                </Modal.Footer>
            </Modal>
        </div>
    );
}
