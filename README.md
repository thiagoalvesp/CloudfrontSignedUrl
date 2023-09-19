# Utilizando a URL pré assinada do CloudFront 

O que você vai encontrar nesse material:
- Objetivo
- Diferença entre a url pré assinada Cloudfront e a url pré assinada do S3
- Componentes necessários na AWS
- Criando o Bucket S3
- Criando o CloudFront
- Criando a chave rsa publica e privada e exemplos
- Configurando a chave no CloudFront
- Diferença entre CannedSignedURL e CustomSignedURL
- Utilizando o SDK AWS .Net
- Implementação do CannedSignedURL
- Implementação do CustomSignedURL
- Fontes

### Objetivo

Em alguns cenários precisamos disponiblizar um arquivo dentro de repositório privado na AWS garantido a segurança e controle de acesso. O Objetivo dessa prova de conceito é apresentar como podemos fazer isso utlizando o CloudFront e apresentar alguns detalhes técnicos dessa funcionalidade.
    
### Diferença entre a url pré assinada Cloudfront e a url pré assinada do S3


### Componentes necessários na AWS

Para essa prova de conceito é necessário: 
- Conta aws (free tier)
- Configurar uma distribuição CloudFront
- Configurar um Bucket S3
- Upload Arquivo de teste (.jpg)
- Aplicação console (.net core 3.1) e o pacote AWSSDK.CloudFront.

Agora que já sabemos o que precisa ser feito, mão na massa!!!

### Criando o Bucket S3

Para criar o bucket na aws podemos utilizar a console (https://s3.console.aws.amazon.com/s3/bucket/create?region=sa-east-1) ou utilizando cli 
```bash
aws s3api create-bucket --bucket <NOME_DO_BUCKET> --region <NOME_DA_REGIÃO>
```

Para o upload podemos utilizar o cli ou a console.
```
aws s3 cp <CAMINHO_DO_ARQUIVO_LOCAL> s3://<NOME_DO_BUCKET>/<CAMINHO_NO_BUCKET>
```

Observação: Foi utilizando a criptografia SSE-S3 e todos os objetos do bucket estão com acesso bloqueado ao público. Podemos disponibilizar arquivos de outras origens além do S3, por exemplo EC2 ou ECS.

### Criando o CloudFront

Via cli temos que criar um json com as especificações. conforme o exemplo abaixo.
```json
{
  "Comment": "Minha distribuição do CloudFront",
  "Origins": {
    "Quantity": 1,
    "Items": [
      {
        "Id": "minha-origem-s3",
        "DomainName": "<ORIGEM_S3_URL>",
        "S3OriginConfig": {
          "OriginAccessIdentity": ""
        }
      }
    ]
  },
  "DefaultCacheBehavior": {
    "TargetOriginId": "minha-origem-s3",
    "ViewerProtocolPolicy": "redirect-to-https",
    "DefaultTTL": 86400
  },
  "Enabled": true,
  "DefaultRootObject": "index.html",
  "PriceClass": "PriceClass_100",
  "ViewerCertificate": {
    "CloudFrontDefaultCertificate": true
  },
  "AllowedMethods": {
    "Quantity": 2,
    "Items": ["GET", "HEAD"]
  },
  "Compress": false,
  "SmoothStreaming": false,
  "Restrictions": {
    "GeoRestriction": {
      "RestrictionType": "whitelist",
      "Quantity": 2,
      "Items": ["US", "CA"]
    }
  }
}
```
Depois executar o comando.
```bash
aws cloudfront create-distribution --distribution-config file://<NOME_DA_CONFIG_JSON> --output json > distribution-output.json
```

Para facilitar o entendimento farei via o passo a passo na console.


### Criando a chave rsa publica e privada e exemplos
### Configurando a chave no CloudFront
### Diferença entre CannedSignedURL e CustomSignedURL
### Criando a aplicação 
### Utilizando o SDK AWS .Net
### Implementação do CannedSignedURL
### Implementação do CustomSignedURL

### Fontes

https://www.udemy.com/course/aws-certified-developer-associate-dva-c01
https://www.youtube.com/watch?v=NTOCzsn7b4A

