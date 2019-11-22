## Change log

- Removed view representation from Member and Boat models
- Removed static operations from FileHandler
- Moved some operations from the controller Secretary to the model FileHandler since it should be responsible for those operations
- Id for members is now handled in FileHandler so they are unique. Also determines the highest id in the json and continues incrementing from that on app restart.
- Moved some logic from controller to view since it can handle read operations from models
- Broke up the view UserInterface into MemberView and BoatView to increase cohesion
- Updated class diagram
- Updated sequence diagram of Register Member
- Updated sequence diagram of Show Member List
