# NineChronicles Standalone

## Run

```
$ dotnet run --project ./NineChronicles.Standalone.Executable/ -- --help

Usage: NineChronicles.Standalone.Executable [--app-protocol-version <Int32>] [--genesis-block-path <String>] [--no-miner] [--host <String>] [--port <Nullable`1>] [--private-key <String>] [--store-type <String>] [--store-path <String>] [--ice-server <String>...] [--peer <String>...] [--rpc-server] [--rpc-listen-host <String>] [--rpc-listen-port <Nullable`1>] [--help] [--version]

Run standalone application with options.

Options:
  -V, --app-protocol-version <Int32>     (Required)
  -G, --genesis-block-path <String>      (Required)
  --no-miner
  --no-trusted-state-validators
  -H, --host <String>                    (Default: )
  -P, --port <Nullable`1>                (Default: )
  --private-key <String>                 (Default: )
  --store-type <String>                  (Default: )
  --store-path <String>                  (Default: )
  -I, --ice-server <String>...           (Default: )
  --peer <String>...                     (Default: )
  --rpc-server                          
  --rpc-listen-host <String>             (Default: 0.0.0.0)
  --rpc-listen-port <Nullable`1>         (Default: )
  -h, --help                            Show help message
  --version                             Show version
```

## Docker Build

솔루션이 위치한 디렉토리에서 아래의 명령어를 실행함으로써 Standalone 이미지를 만들 수 있습니다.

```
$ docker build . -t <IMAGE_TAG>
```

### Command Line Options

- `-H`, `--host`: 사용할 Host 이름을 지정합니다.
- `-P`, `--port`: 사용할 Port를 지정합니다.
- `--private-key`: 사용할 프라이빗 키를 지정합니다.
- `--no-miner`: 마이닝을 사용하지 않습니다.
- `--no-trusted-state-validators`: 지정한 피어로부터 계산된 상태를 받지 않고 모든 상태를 직접 계산합니다.
- `--store-path`: 데이터를 저장할 경로를 지정합니다.
- `-I`, `--ice-server`: NAT 우회에 사용할 TURN 서버 정보를 지정합니다. 지정하는 서버가 여럿일 경우 `--ice-server serverA --ice-serverserverB`와 같이 추가할 수 있습니다.
- `--peer`: Peer 를 추가합니다. 추가하려는 Peer가 여럿일 경우 `--peer peerA --peer peerB ...` 와 같이 추가할 수 있습니다.
- `-G`, `--genesis-block-path`: 제네시스 블록의 경로를 지정합니다.
- `-V`, `--app-protocol-version`: `Swarm<T>.AppProtocolVersion`의 값을 지정합니다.
- `--rpc-server`: RPC 서버 모드로 시작합니다. 이 플래그가 설정되면 `--rpc-listen-port`를 지정해야 합니다.
- `--rpc-listen-host`: RPC 서버 모드에서 사용할 호스트명입니다.
- `--rpc-listen-port`: RPC 서버 모드에서 사용할 포트입니다.

### 형식

`PrivateKey`나 `Peer`에 대한 형식은 [Nekoyume 프로젝트 README][../README.md]의 형식을 따릅니다.
