# FAR Manager NetBox Password Decryptor

A utility for decrypting (un-scrambling) passwords stored
by FAR Manager's NetBox plugin.


## Overview

[FAR Manager](https://farmanager.com/) is a popular file
and archive manager for Windows, and
[NetBox](https://plugring.farmanager.com/plugin.php?pid=859)
is one of its plugins that provides network connectivity
features, including FTP, SFTP, and more.

The NetBox plugin stores connection passwords in an
non-readable (scrambled) format, which can be inconvenient
if you lose access or need to recover them for migration
or auditing purposes.

This tool provides a way to "decrypt" (un-scramble)
those passwords.


## Features

- **Decrypt NetBox Passwords:** Extract and decrypt passwords saved by the NetBox plugin.
- **Simple CLI or Programmatic Use:** Designed for ease of use, whether you want to run it directly or integrate into other C# workflows.
- **Open Source:** Fully open source for transparency and community collaboration.

 
## Technologies Used

- **C#** (.NET)


## Build Instructions

1. **Clone the repository:**
    ```sh
    git clone https://github.com/ghcentre/far-manager-netbox-password-decryptor.git
    ```

2. **Build the project:**

    Change to project root directory and run:

    * Windows (cmd):
      ```sh
      build.cmd
      ```
    * Linux:
      ```
      chmod +x ./build.sh
      ./build.sh
      ```

**NOTE:** Build produces Windows binaries only. 
This tool is useless in Lunux because of Windows-only
nature of the FAR Manager and its NetBox plugin.


## How to Recover Lost Passwords with this Tool

1. Start FAR Manager.

2. Press `F11` key to open Command Plugins menu.

3. Select `NetBox` from the list.

4. On a passive FAR Manager panel, select any local filesystem
   folder (e.g. `C:\TEMP`).

5. On a NetBox panel, highlight a session you want to
   recover password from.

6. Export the session: press `F5` to open export dialog, and
   `Enter` to confirm.

7. Run the tool to display saved password:
   ```sh
   FarNetboxPasswordDecryptor C:\TEMP\session.netbox
   ```
   where `session.netbox` is the name of the exported
   session file.


## License

This project is licensed under the MIT License.
See [LICENSE](LICENSE) for details.


## Contributing

Contributions are welcome! Open an issue or submit a pull request to suggest improvements or add features.


## Disclaimer

This tool is not affiliated with or endorsed by the developers of FAR Manager or the NetBox plugin.