# 2D2D - Dimensional Puzzle Platformer

Welcome to **2D2D**, a challenging dimensional puzzle platformer where players navigate across multiple 2D planes to overcome complex obstacles. Designed with smooth mechanics and responsive controls, **2D2D** offers a unique experience that leverages dimension-switching gameplay.

[![Gameplay GIF](link_to_main_gameplay_gif.gif)](link_to_main_gameplay_gif.gif)

## Table of Contents
- [Features](#features)
- [Mechanics](#mechanics)
- [Installation](#installation)
- [Gameplay Controls](#gameplay-controls)
- [Contribution Guidelines](#contribution-guidelines)
- [License](#license)

## Features

- **Smooth 2D Movement**: Seamless horizontal and vertical movement for precise control.
- **Dimension Switching**: Toggle between dimensions to unlock new paths and solve puzzles.
- **Responsive Jump Mechanics**: Enhanced controls with Coyote Time and Jump Buffering, allowing for tighter platforming.
- **Variable Jump Heights**: Release the jump button early to control your jump height dynamically.

## Mechanics

Here’s a breakdown of each core mechanic with examples and code snippets.

### Basic 2D Movement
Smooth horizontal movement that forms the foundation of **2D2D** gameplay.

![Basic Movement GIF](link_to_basic_movement_gif.gif)

```csharp
// Basic 2D Movement
private void MovePlayer() {
    Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
    rb.velocity = movementDirection;
}
Dimension Switching
Switch between dimensions to access alternate paths and hidden platforms.


Code Overview:
csharp
Copy code
// Dimension Switching Code
private void SwitchDimension() {
    // Logic for toggling between dimensions
}
Coyote Time Mechanic
Allows a brief grace period after leaving a platform for smoother jumps.


csharp
Copy code
// Coyote Time Mechanic
private void UpdateCoyoteTime() {
    if (IsGrounded()) {
        coyoteTimeCounter = coyoteTime; // Reset if grounded
    } else {
        coyoteTimeCounter -= Time.deltaTime; // Decrease over time
    }
}
Jump Buffer Mechanic
Adds a buffer for jump input, making jumps more responsive and forgiving.


csharp
Copy code
// Jump Buffer Mechanic
private void UpdateJumpBuffer() {
    if (Input.GetButtonDown("Jump")) {
        jumpBufferCounter = jumpBufferTime; // Reset buffer
    } else {
        jumpBufferCounter -= Time.deltaTime;
    }
}
Ground Check
Checks if the player is grounded to ensure proper jump mechanics.


csharp
Copy code
// Ground Check
private bool IsGrounded() {
    return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
}
Variable Jump Height
Allows players to control jump height by releasing the jump button early.


csharp
Copy code
// Variable Jump Height
private void ApplyVariableJumpHeight() {
    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Shorten jump height
    }
}
Installation
To set up 2D2D locally, follow these steps:

Clone the Repository:

bash
Copy code
git clone https://github.com/GaMerijn2/IEGJ-2024.git
Open in Unity:

Ensure you have Unity version X.X.X or higher.
Open the project in Unity and allow it to load all dependencies.
Build and Run:

Configure your build settings, then hit Play to start testing the game in the editor.
Gameplay Controls
Move: Left and Right Arrow Keys or A and D
Jump: Spacebar
Dimension Switch: Key (specific key, e.g., E)
Contribution Guidelines
Contributions are welcome! Please fork the repository and create a pull request with a clear description of your changes. If you want to discuss ideas before coding, feel free to open an issue.

License
This project is licensed under the MIT License - see the LICENSE file for details.

Enjoy exploring dimensions with 2D2D! For any questions or feedback, feel free to reach out via GitHub Issues.
