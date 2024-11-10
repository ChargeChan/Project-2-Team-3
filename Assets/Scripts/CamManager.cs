using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamManager : MonoBehaviour
{
    public Camera[] cameras;
    public Button leftArrow;
    public Button rightArrow;
    public Button forwardArrow;
    public Button backArrow;
    public Button Leave;

    private int currentCameraIndex = 0;
    private const int jigsawCameraIndex = 21;
    private JigsawClick jigsawClick;


    // Holds navigation options for each camera
    private Dictionary<int, CameraNavigation> cameraNavigationMap;

    void Start()
    {
        // Initialize the camera navigation map
        InitializeNavigationMap();

        // Set the first camera as active
        SetActiveCamera(13);
        UpdateUI();

        // Assign button functionality
        leftArrow.onClick.AddListener(MoveLeft);
        rightArrow.onClick.AddListener(MoveRight);
        forwardArrow.onClick.AddListener(MoveForward);
        backArrow.onClick.AddListener(MoveBackward);
        Leave.onClick.AddListener(MoveLeave);
        Leave.onClick.AddListener(LeavePuzzle);

        jigsawClick = FindObjectOfType<JigsawClick>();


    }

    public void LeavePuzzle()
    {
        if (jigsawClick != null)
        {
            jigsawClick.LeavePuzzle();  // Calls the LeavePuzzle() method from JigsawClick script
        }
    }

    void InitializeNavigationMap()
    {
        // Dictionary with each camera's available directions
        cameraNavigationMap = new Dictionary<int, CameraNavigation>
        {
            { 0, new CameraNavigation(forward: 3, left: 1, right: 2)},
            { 1, new CameraNavigation(right: 3)},
            { 2, new CameraNavigation(forward: 11, left: 3)},
            { 3, new CameraNavigation(back: 16, forward: 6, left: 4, right: 7)},
            { 4, new CameraNavigation(back: 3, left: 1, right: 5)},
            { 5, new CameraNavigation(back: 6, left: 4)},
            { 6, new CameraNavigation(back: 15, forward: 18, left: 5, right: 7)},
            { 7, new CameraNavigation(back: 6)},
            { 8, new CameraNavigation(back: 17, left: 9, right: 10)},
            { 9, new CameraNavigation(back: 17, left: 17)},
            {10,  new CameraNavigation(left: 8, right: 17)},
            {11,  new CameraNavigation(forward: 19, left: 0)},
            {12,  new CameraNavigation(back: 11, right: 0)},
            {13,  new CameraNavigation(back: 19, left: 12)},
            {14,  new CameraNavigation(right: 20)},
            {15,  new CameraNavigation(back: 6, forward: 16, right: 4)},
            {16,  new CameraNavigation(back: 0, left: 2, right: 1)},
            {17,  new CameraNavigation(back: 18, forward: 15, left: 7, right: 5)},
            {18,  new CameraNavigation(back: 17, forward: 8, left: 9)},
            {19,  new CameraNavigation(forward: 14, left: 13)},
            {20,  new CameraNavigation(forward: 12, right: 13)},
            {21,  new CameraNavigation(leave: 13)}




        };
    }

    public void SetActiveCamera(int index)
    {
        // Deactivate all cameras
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index); // Only activate the desired camera
        }

        currentCameraIndex = index;

        // Show or hide UI elements based on the camera index
        if (index == jigsawCameraIndex) // Cam21
        {
            // Only show the Leave button and hide other UI elements
            ToggleUI(false); // Hide navigation UI elements
            ShowLeaveButton(true); // Show the Leave button
        }
        else
        {
            // Show main UI for other cameras
            ShowLeaveButton(false); // Hide the Leave button
            ToggleUI(true); // Show main UI
            UpdateUI();
        }
    }

    public Camera GetCamera(int cameraIndex)
    {
        // Return the camera at the specified index if it's valid
        if (cameraIndex >= 0 && cameraIndex < cameras.Length)
        {
            return cameras[cameraIndex];
        }
        else
        {
            Debug.LogError("Camera index out of range!");
            return null;
        }
    }

    void UpdateUI()
    {
        // Enable or disable buttons based on available directions from current camera
        CameraNavigation nav = cameraNavigationMap[currentCameraIndex];
        forwardArrow.gameObject.SetActive(nav.forward != -1);
        backArrow.gameObject.SetActive(nav.back != -1);
        Leave.gameObject.SetActive(nav.leave != -1);
        leftArrow.gameObject.SetActive(nav.left != -1);
        rightArrow.gameObject.SetActive(nav.right != -1);
    }

    public void ShowLeaveButton(bool isVisible)
    {
        Leave.gameObject.SetActive(isVisible); // Make the Leave button visible or hidden
    }

    void ToggleUI(bool show)
    {
        leftArrow.gameObject.SetActive(show);
        rightArrow.gameObject.SetActive(show);
        forwardArrow.gameObject.SetActive(show);
        backArrow.gameObject.SetActive(show);
    }

    // Movement functions that check for valid navigation options
    void MoveLeft()
    {
        int targetCamera = cameraNavigationMap[currentCameraIndex].left;
        if (targetCamera != -1) SetActiveCamera(targetCamera);
        UpdateUI();
    }

    void MoveRight()
    {
        int targetCamera = cameraNavigationMap[currentCameraIndex].right;
        if (targetCamera != -1) SetActiveCamera(targetCamera);
        UpdateUI();
    }

    void MoveForward()
    {
        int targetCamera = cameraNavigationMap[currentCameraIndex].forward;
        if (targetCamera != -1) SetActiveCamera(targetCamera);
        UpdateUI();
    }

    void MoveBackward()
    {
        int targetCamera = cameraNavigationMap[currentCameraIndex].back;
        if (targetCamera != -1) SetActiveCamera(targetCamera);
        UpdateUI();
    }

    void MoveLeave()
    {
        int targetCamera = cameraNavigationMap[currentCameraIndex].leave;
        if (targetCamera != -1) SetActiveCamera(targetCamera);
        UpdateUI();
    }
}

// Helper class to store navigation options for each camera
public class CameraNavigation
{
    public int left, right, forward, back, leave;

    public CameraNavigation(int left = -1, int right = -1, int forward = -1, int back = -1, int leave =-1)
    {
        this.left = left;
        this.right = right;
        this.forward = forward;
        this.back = back;
        this.leave = leave;
    }
}
