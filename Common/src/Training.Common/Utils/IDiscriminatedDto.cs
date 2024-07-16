namespace Training.Common.Utils;

public interface IDiscriminatedDto
{
    string TypeDiscriminator => this.GetType().Name;
}