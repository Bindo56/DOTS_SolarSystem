
Unity’s DOTS Fundamentals for ECS and put the concepts into practice by building a real-time solar system simulation running 100,000+ entities.


https://github.com/user-attachments/assets/17832324-8373-49b8-956e-bd4ee6e78fad

[Play the Solar DOTS browser world](https://bindo56.github.io/worlds/event-horizon/) — an interactive Three.js interpretation of this Unity ECS and Burst project.


I worked with ISystem, IJobEntity, Burst-compiled jobs, and EndSimulationEntityCommandBufferSystem to handle large-scale gravitational motion efficiently. Using subscenes, bakers, and chunk-based data layout made it possible to simulate thousands of bodies with stable performance.

A great deep dive into data-oriented programming, parallel processing, and high-performance gameplay systems.

Key Technical Highlights:

• Used ISystem for orchestration and job scheduling, and IJobEntity for per-entity simulation steps.

• Implemented gravitational motion using Burst-compiled jobs for high-performance math across all bodies.

• Leveraged EndSimulationEntityCommandBufferSystem to safely handle structural changes like entity destruction.

• Worked with EntityQuery, SystemAPI.Query, and baking workflows to convert authoring data into efficient ECS runtime components.

• Spawned and simulated 100,000 entities with stable framerate due to cache-friendly, chunk-based data layout.

• Applied inverse-square-law gravity calculations and implemented rules for entity cleanup to maintain simulation stability.

• Explored subscenes, bakers, and conversion pipelines to optimize scene setup.
