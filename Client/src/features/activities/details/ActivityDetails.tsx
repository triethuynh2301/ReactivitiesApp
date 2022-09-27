import React from "react";
import { Button, ButtonGroup, Card, Image } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface ActivityDetailsProps {
  activity: Activity;
}

const ActivityDetails: React.FC<ActivityDetailsProps> = ({ activity }) => {
  return (
    <Card fluid>
      <Image
        src={
          new URL(
            `../../../assets/categoryImages/${activity.category}.jpg`,
            import.meta.url
          ).href
        }
      />
      <Card.Content>
        <Card.Header>{activity.title}</Card.Header>
        <Card.Meta>
          <span className="date">{activity.date}</span>
        </Card.Meta>
        <Card.Description>{activity.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <ButtonGroup widths={2}>
          <Button basic color="blue" content="Edit" />
          <Button basic color="grey" content="Cancel" />
        </ButtonGroup>
      </Card.Content>
    </Card>
  );
};

export default ActivityDetails;
